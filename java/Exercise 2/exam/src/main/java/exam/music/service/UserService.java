package exam.music.service;

import exam.music.model.binding.UserLoginBindingModel;
import exam.music.model.entity.User;
import exam.music.model.service.UserServiceModel;

public interface UserService {
    UserServiceModel FindByUsername(UserLoginBindingModel userLoginBindingModel);
    UserServiceModel add(UserServiceModel model);
User getUserByEmail(String email);
    UserServiceModel FindByEmail(UserLoginBindingModel userLoginBindingModel);
}
