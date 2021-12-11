package exam.music.service.impl;

import exam.music.model.entity.ProductEntity;
import exam.music.model.service.ProductServiceModel;
import exam.music.model.view.ProductViewModel;
import exam.music.repository.ProductRepository;
import exam.music.service.CategoryService;
import exam.music.service.ProductService;
import exam.music.service.SexService;
import org.modelmapper.ModelMapper;
import org.springframework.stereotype.Service;

import java.util.List;
import java.util.stream.Collectors;

@Service
public class ProductServiceImpl implements ProductService {

    private final ProductRepository productRepository;
    private final CategoryService categoryService;
    private final SexService sexService;
    private final ModelMapper modelMapper;

    public ProductServiceImpl(ProductRepository productRepository, CategoryService categoryService, SexService service, ModelMapper modelMapper) {
        this.productRepository = productRepository;
        this.categoryService = categoryService;
        this.sexService = service;
        this.modelMapper = modelMapper;
    }

    @Override
    public List<ProductViewModel> findAll() {
        return productRepository.findAll()
                .stream().map(e-> mapProduct(e)).collect(Collectors.toList());
    }

    @Override
    public ProductViewModel findById(String id) {
        return mapProduct(productRepository.findById(id)
                        .orElseThrow(() -> new NullPointerException("Product does not exist")));
    }

    @Override
    public void add(ProductServiceModel model) {


        ProductEntity product = modelMapper.map(model, ProductEntity.class);
        product.setCategory(this.categoryService.findByName(model.getCategory().getName()));
        product.setSex(this.sexService.findByName(model.getSex().getName()));
        this.productRepository.saveAndFlush(product);
    }

    @Override
    public void delete(String id) {
        this.productRepository.deleteById(id);
    }
    private ProductViewModel mapProduct(ProductEntity e){
        ProductViewModel map = modelMapper.map(e, ProductViewModel.class);
        map.setImageUrl( String.format("/img/%s-%s.jpg"
                ,e.getSex().getName().toUpperCase()
                , e.getCategory().getName().toUpperCase()
        ));
        return map;
    }
}
