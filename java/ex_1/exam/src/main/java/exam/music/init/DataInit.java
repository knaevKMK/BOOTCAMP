package exam.music.init;

import exam.music.service.CategoryService;
import exam.music.service.SexService;
import org.springframework.boot.CommandLineRunner;

public class DataInit implements CommandLineRunner {

    private final CategoryService categoryService;
    private final SexService genderService;

    public DataInit(CategoryService categoryService, SexService genderService) {
        this.categoryService = categoryService;
        this.genderService = genderService;
    }


    @Override
    public void run(String... args) throws Exception {
        this.categoryService.seedData();
        this.genderService.seedData();
    }
}