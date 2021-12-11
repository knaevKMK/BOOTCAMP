package exam.music.repository;

import exam.music.model.entity.Classification;
import exam.music.model.enums.ClassificationEnum;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import java.util.Optional;

@Repository
public interface ClassificationRepository extends JpaRepository<Classification, String> {
    Optional<Classification> findByClassificationName(ClassificationEnum classificationEnum);
}
