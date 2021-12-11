package exam.music.service.impl;

import exam.music.model.entity.Classification;
import exam.music.model.enums.ClassificationEnum;
import exam.music.repository.ClassificationRepository;
import exam.music.service.ClassificationService;
import org.springframework.stereotype.Service;

import java.util.Arrays;
import java.util.Collection;

@Service
public class ClassificationServiceImpl implements ClassificationService {
    private  final ClassificationRepository classificationRepository;

    public ClassificationServiceImpl(ClassificationRepository classificationRepository) {
        this.classificationRepository = classificationRepository;
    }

    @Override
    public void seedData() {
        if (classificationRepository.count()>0){return;}
        Arrays.stream(ClassificationEnum.values())
                .forEach(classEnum->{
                    var classification = new Classification();
                    classification.setClassificationName(classEnum);
                    classification.setDescription("Description for "+ classEnum.getName());
                 this.create(classification);
                });
    }

    @Override
    public String create(Classification classification) {

        Classification _classification = classificationRepository.saveAndFlush(classification);
        return _classification!=null? _classification.getId():null;
    }

    @Override
    public Classification getById(String id) {
        return classificationRepository.findById(id)
                .orElseThrow(()-> new NullPointerException("Classification with current id does not exist"));
    }

    @Override
    public Classification getByName(String name) {
        return classificationRepository.findByClassificationName(ClassificationEnum.valueOf(name.toUpperCase()))
                .orElseThrow(()-> new NullPointerException("Classification with current id does not exist"));
    }

    @Override
    public Collection<Classification> getAll() {
        return classificationRepository.findAll();
    }
}
