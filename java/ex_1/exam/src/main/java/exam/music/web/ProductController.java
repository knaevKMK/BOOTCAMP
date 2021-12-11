package exam.music.web;

import exam.music.model.binding.ProductAddBindingModel;
import exam.music.model.service.ProductServiceModel;
import exam.music.model.view.ProductViewModel;
import exam.music.service.ProductService;
import org.modelmapper.ModelMapper;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.validation.BindingResult;
import org.springframework.web.bind.annotation.*;
import org.springframework.web.servlet.ModelAndView;
import org.springframework.web.servlet.mvc.support.RedirectAttributes;

import javax.servlet.http.HttpSession;
import javax.validation.Valid;

@Controller
@RequestMapping("/products")
public class ProductController {
    private final ProductService productService;
    private final ModelMapper modelMapper;

    public ProductController(ProductService productService, ModelMapper modelMapper) {
        this.productService = productService;
        this.modelMapper = modelMapper;
    }
    @GetMapping("/add")
    public String add(Model model, HttpSession session){
        if (session.getAttribute("user") == null) {
            return "redirect:/users/login";
        }
        if (!model.containsAttribute("productAddBindingModel")) {
            model.addAttribute("productAddBindingModel", new ProductAddBindingModel());
        }
        return "add-product";
    }



    @PostMapping("/add")
    public String addConfirm(@Valid @ModelAttribute("productAddBindingModel")ProductAddBindingModel productAddBindingModel,
                             BindingResult bindingResult,
                             RedirectAttributes redirectAttributes,
                             HttpSession session){
        if (session.getAttribute("user") == null) {
            return "redirect:/users/login";
        }

        if (bindingResult.hasErrors()) {
            redirectAttributes.addFlashAttribute("productAddBindingModel", productAddBindingModel);
            redirectAttributes.addFlashAttribute("org.springframework.validation.BindingResult.productAddBindingModel", bindingResult);
            return "redirect:/products/add";
        }
        this.productService.add(modelMapper.map(productAddBindingModel, ProductServiceModel.class));

        return "redirect:/";
    }

    @GetMapping("/details")
    public ModelAndView details(@RequestParam("id") String id, HttpSession session){
        ModelAndView modelAndView= new ModelAndView();

        if (session.getAttribute("user")==null){
            modelAndView.setViewName("redirect:/users/login");
        }else {

            ProductViewModel productViewModel= productService.findById(id);
            if (productViewModel==null){
                modelAndView.setViewName("redirect:/");
            }else {
                modelAndView.addObject("product", productViewModel);
                modelAndView.setViewName("details-product");
            }
        }

        return modelAndView;
    }

    @GetMapping("/delete")
    public  String delete(@RequestParam("id") String id, HttpSession session){
        if (session.getAttribute("user") == null) {
            return "redirect:/users/login";
        }
        this.productService.delete(id);
        return "redirect:/";
    }
}
