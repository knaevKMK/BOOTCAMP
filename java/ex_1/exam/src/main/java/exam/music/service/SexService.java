package exam.music.service;


import exam.music.model.entity.SexEntity;

public interface SexService {
    void seedData();
    SexEntity findById(String id);
    SexEntity findByName(String name);
}
