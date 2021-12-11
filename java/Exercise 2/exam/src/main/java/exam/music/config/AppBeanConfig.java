package exam.music.config;

import exam.music.model.binding.TaskBindingModel;
import exam.music.model.service.TaskServiceModel;
import org.modelmapper.ModelMapper;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;

import java.time.LocalDate;

@Configuration
public class AppBeanConfig {

    @Bean
    public  ModelMapper modelMapper(){
        var modelMapper=new ModelMapper();
//        modelMapper.createTypeMap(TaskBindingModel.class, TaskServiceModel.class)
//                .addMapping(src->LocalDate.parse(src.getDueDate()), TaskServiceModel::setDueDate);
        return  modelMapper;
    }
}
