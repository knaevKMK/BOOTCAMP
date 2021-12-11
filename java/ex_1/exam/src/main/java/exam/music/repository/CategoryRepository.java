package exam.music.repository;;

import exam.music.model.entity.CategoryEntity;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;


import java.util.Optional;

@Repository
public interface CategoryRepository extends JpaRepository<CategoryEntity,String> {
    Optional<CategoryEntity> findByName(String name);
}
