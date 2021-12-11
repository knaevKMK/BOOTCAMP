package exam.music.web;

import exam.music.model.view.TaskViewModel;
import exam.music.service.impl.TaskService;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.servlet.ModelAndView;

import javax.servlet.http.HttpSession;
import java.util.List;

@Controller
public class HomeController {
    private final TaskService taskService;

    public HomeController(TaskService taskService) {
        this.taskService = taskService;
    }
    @GetMapping("/")
    public ModelAndView home(ModelAndView modelAndView,HttpSession session){
        if (session.getAttribute("user")==null){
            modelAndView.setViewName("index");
        }else {
            List<TaskViewModel> all = taskService.getAll();
            modelAndView.addObject("all", all);
            modelAndView.setViewName("home");
        }
        return  modelAndView;
    }
}
