package exam.music.web;

import exam.music.model.binding.TaskBindingModel;
import exam.music.model.service.TaskServiceModel;
import exam.music.model.service.UserServiceModel;
import exam.music.model.view.UserViewModel;
import exam.music.service.impl.TaskService;
import org.modelmapper.ModelMapper;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.validation.BindingResult;
import org.springframework.web.bind.annotation.*;
import org.springframework.web.servlet.mvc.support.RedirectAttributes;

import javax.servlet.http.HttpSession;
import javax.validation.Valid;
import java.time.LocalDate;

@Controller
@RequestMapping("/tasks")
public class TaskController {

    private final TaskService taskService;
    private final ModelMapper modelMapper;

    public TaskController(TaskService taskService, ModelMapper modelMapper) {
        this.taskService = taskService;
        this.modelMapper = modelMapper;
    }

    @GetMapping("/add")
    public String create(Model model,HttpSession session) {
        if (session.getAttribute("user") == null) {
            return "redirect:/users/login";
        }
        if (!model.containsAttribute("taskBindingModel")) {
            model.addAttribute("taskBindingModel", new TaskBindingModel());
        }
        return "add-task";
    }


    @PostMapping("addConfirm")
    public String addConfirm(@Valid @ModelAttribute("taskBindingModel") TaskBindingModel taskBindingModel,
                             BindingResult bindingResult,
                             RedirectAttributes redirectAttributes,
                             HttpSession session) {
        if (session.getAttribute("user") == null) {
            return "redirect:/users/login";
        }
        if (bindingResult.hasErrors()) {
            redirectAttributes.addFlashAttribute("taskBindingModel", taskBindingModel);
            redirectAttributes.addFlashAttribute("org.springframework.validation.BindingResult.taskBindingModel", bindingResult);

            return "redirect:/tasks/add";
        }
        try {
            redirectAttributes.addFlashAttribute("fatalError", false);
            TaskServiceModel taskServiceModel = modelMapper.map(taskBindingModel, TaskServiceModel.class);
            taskServiceModel.setDueDate(LocalDate.parse(taskBindingModel.getDueDate()));
            taskServiceModel.setUserViewModel((UserViewModel)session.getAttribute("user"));
            taskService.create(taskServiceModel);
            return "redirect:/";
        } catch (Exception e) {
            redirectAttributes.addFlashAttribute("fatalError", e.getMessage());

            return "redirect:/tasks/add";
        }


    }
    @GetMapping("/progress")
    public String progress(@RequestParam("id") String id, HttpSession session) {
    if (session.getAttribute("user") == null) {
        return "redirect:/users/login";
    }
   taskService.onProgress(id);
    return "redirect:/";
}
}
