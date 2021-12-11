package exam.music.web;

import exam.music.model.view.ProductViewModel;
import exam.music.service.ProductService;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.servlet.ModelAndView;

import javax.servlet.http.HttpSession;
import java.util.List;

@Controller
public class HomeController {

    private final ProductService productService;

    public HomeController(ProductService productService) {
        this.productService = productService;
    }

    @GetMapping("/")
    public ModelAndView home(ModelAndView modelAndView,HttpSession session){
        if (session.getAttribute("user")==null){
            modelAndView.setViewName("index");
        }else {
            List<ProductViewModel> productViewModels= productService.findAll();
            modelAndView.addObject("all" , productViewModels);
            modelAndView.setViewName("home");
        }
        return  modelAndView;
    }
}
