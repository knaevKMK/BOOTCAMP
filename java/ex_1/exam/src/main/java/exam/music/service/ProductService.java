package exam.music.service;

import exam.music.model.service.ProductServiceModel;
import exam.music.model.view.ProductViewModel;

import java.util.Collection;
import java.util.List;

public interface ProductService {
    List<ProductViewModel> findAll();

    ProductViewModel findById(String id);

    void add(ProductServiceModel model);

    void delete(String id);
}
