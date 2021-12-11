package exam.music.service.impl;

import exam.music.model.entity.CategoryEntity;
import exam.music.model.enums.CategoryEnum;
import exam.music.repository.CategoryRepository;
import exam.music.service.CategoryService;
import org.springframework.stereotype.Service;

import java.util.Arrays;

@Service
public class CategoryServiceImpl implements CategoryService {
    private final CategoryRepository categoryRepository;

    public CategoryServiceImpl(CategoryRepository categoryRepository) {
        this.categoryRepository = categoryRepository;
    }

    @Override
    public void seedData() {
        if (categoryRepository.count()>0){return;}
        Arrays.stream(CategoryEnum.values())
                .forEach(categoryEnum -> {
                    CategoryEntity category= new CategoryEntity();
                    category.setCategoryEnum(categoryEnum);
                    category.setName(categoryEnum.getName());
                    categoryRepository.saveAndFlush(category);
                });
    }

    @Override
    public CategoryEntity findById(String id) {
        return categoryRepository.findById(id)
                .orElseThrow(()-> new NullPointerException("Category does not exist"));
    }

    @Override
    public CategoryEntity findByName(String name) {
        return categoryRepository.findByName(name)
                .orElseThrow(()->new NullPointerException("\"Category with name "+name+" does not exist\""));
    }
}
