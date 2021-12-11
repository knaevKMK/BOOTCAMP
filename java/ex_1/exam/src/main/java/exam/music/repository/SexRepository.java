package exam.music.repository;

import exam.music.model.entity.SexEntity;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import java.util.Optional;

@Repository
public interface SexRepository extends JpaRepository<SexEntity,String> {
    Optional<SexEntity> findByName(String name);
}
