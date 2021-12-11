package exam.music.config;

import exam.music.model.entity.ProductEntity;
import exam.music.model.view.ProductViewModel;
import org.modelmapper.ModelMapper;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;

@Configuration
public class AppBeanConfig {

    @Bean
    public ModelMapper modelMapper() {
        ModelMapper modelMapper = new ModelMapper();
//        modelMapper.createTypeMap(ProductEntity.class, ProductViewModel.class)
//                .addMapping(src -> String.format("/img/%s-%s.jpg"
//                                , src.getCategory().getCategoryEnum().name()
//                                , src.getSex().getSexEnum() .name()
//                        , ProductViewModel::setImageUrl);
        return modelMapper;
    }
}
