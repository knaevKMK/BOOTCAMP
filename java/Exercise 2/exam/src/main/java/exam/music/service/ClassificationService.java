package exam.music.service;

import exam.music.model.entity.Classification;

import java.util.Collection;

public interface ClassificationService {
    void seedData();
    String create(Classification classification);
    Classification getById(String id);
    Classification getByName(String name);
Collection<Classification> getAll();
}
