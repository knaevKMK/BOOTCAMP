package exam.music.service.impl;

import org.springframework.stereotype.Service;
import exam.music.model.entity.SexEntity;
import exam.music.model.enums.SexEnum;
import exam.music.repository.SexRepository;
import exam.music.service.SexService;

import java.util.Arrays;

@Service
public class SexServiceImpl implements SexService {
    private final SexRepository sexRepository;

    public SexServiceImpl(SexRepository sexRepository) {
        this.sexRepository = sexRepository;
    }

    @Override
    public void seedData() {
        if  (sexRepository.count()>0){return;}
        Arrays.stream(SexEnum.values())
                .forEach(sexEnum -> {
                    SexEntity sex= new SexEntity();
                    sex.setSexEnum(sexEnum);
                    sex.setName(sexEnum.getName());
                    sexRepository.saveAndFlush(sex);
                });
    }

    @Override
    public SexEntity findById(String id) {

        return sexRepository.findById(id)
                .orElseThrow(()->new NullPointerException("Sex does not exist"));
    }

    @Override
    public SexEntity findByName(String name) {
        return sexRepository.findByName(name)
                .orElseThrow(()->new NullPointerException("Sex with name "+name+" does not exist"));
    }
}
