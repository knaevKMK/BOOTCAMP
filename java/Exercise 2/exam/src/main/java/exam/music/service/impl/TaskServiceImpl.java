package exam.music.service.impl;

import exam.music.model.entity.Task;
import exam.music.model.enums.ProgressEnum;
import exam.music.model.service.TaskServiceModel;
import exam.music.model.view.TaskViewModel;
import exam.music.repository.TaskRepository;
import exam.music.service.ClassificationService;
import exam.music.service.UserService;
import org.modelmapper.ModelMapper;
import org.springframework.stereotype.Service;

import javax.transaction.Transactional;
import java.util.List;
import java.util.stream.Collectors;

@Service
public class TaskServiceImpl implements TaskService {
    private final TaskRepository taskRepository;
    private final ModelMapper modelMapper;
    private final ClassificationService classificationService;
    private final UserService userService;

    public TaskServiceImpl(TaskRepository taskRepository, ModelMapper modelMapper,
                           ClassificationService classificationService, UserService userService) {
        this.taskRepository = taskRepository;
        this.modelMapper = modelMapper;
        this.classificationService = classificationService;
        this.userService = userService;
    }

    @Override
    public void create(TaskServiceModel taskServiceModel) {
        Task task = modelMapper.map(taskServiceModel, Task.class);
        task.setUser(userService.getUserByEmail(taskServiceModel.getUserViewModel().getEmail()));
        task.setClassification(classificationService.getByName(taskServiceModel.getClassificationEnum().name()));
        task.setProgress(ProgressEnum.OPEN);

        taskRepository.save(task);
    }

    @Override
    public List<TaskViewModel> getAll() {
        return taskRepository.findAll()
                .stream().map(e -> {
                    TaskViewModel map = modelMapper.map(e, TaskViewModel.class);
                    map.setUserName(e.getName());
                    return map;
                })
                .collect(Collectors.toList());
    }

    @Override
    @Transactional
    public void onProgress(String id) {
        Task task = taskRepository.findById(id).orElseThrow(() -> new NullPointerException("Task gone"));
        switch (task.getProgress()) {
            case OPEN:
                task.setProgress(ProgressEnum.IN_PROGRESS);
                break;
            case IN_PROGRESS:
                task.setProgress(ProgressEnum.COMPLETED);
                break;
            case COMPLETED:
                taskRepository.deleteById(id);
                break;
        }

    }


}
