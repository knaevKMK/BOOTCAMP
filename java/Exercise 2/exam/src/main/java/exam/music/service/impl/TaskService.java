package exam.music.service.impl;

import exam.music.model.service.TaskServiceModel;
import exam.music.model.view.TaskViewModel;

import java.util.List;

public interface TaskService {
    void create(TaskServiceModel taskServiceModel);

    List<TaskViewModel> getAll();

    void onProgress(String id);
}
