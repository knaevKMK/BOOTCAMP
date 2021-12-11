package exam.music.service.impl;

import exam.music.model.binding.UserLoginBindingModel;
import exam.music.model.entity.User;
import exam.music.model.service.UserServiceModel;
import exam.music.repository.UserRepository;
import exam.music.service.UserService;
import org.modelmapper.ModelMapper;
import org.springframework.stereotype.Service;


@Service
public class UserServiceImpl implements UserService {
    private final UserRepository userRepository;
    private final ModelMapper modelMapper;

    public UserServiceImpl(UserRepository userRepository, ModelMapper mapper) {
        this.userRepository = userRepository;
        this.modelMapper = mapper;
    }

    public UserServiceModel add(UserServiceModel model) {
        User user = modelMapper.map(model, User.class);
        User savedUser = userRepository.saveAndFlush(user);
        UserServiceModel _return= modelMapper.map(savedUser,UserServiceModel.class);
        return _return;
    }

    @Override
    public User getUserByEmail(String email) {
        return this.userRepository
                .findByEmail(email).orElseThrow(()->new NullPointerException("Please login"));
    }

    @Override
    public UserServiceModel FindByEmail(UserLoginBindingModel model) {
        return this.userRepository
                .findByEmail(model.getEmail())
                .map(user->modelMapper.map(user,UserServiceModel.class))
                .orElse(null);
    }

    @Override
    public UserServiceModel FindByUsername(UserLoginBindingModel model) {

        return  this.userRepository
                .findByUsername(model.getEmail())
                .map(user->modelMapper.map(user,UserServiceModel.class))
                .orElse(null);
    }
}
