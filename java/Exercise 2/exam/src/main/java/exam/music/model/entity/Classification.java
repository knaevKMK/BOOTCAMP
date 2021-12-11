package exam.music.model.entity;

import exam.music.model.enums.ClassificationEnum;

import javax.persistence.*;
import java.util.List;

@Entity
@Table(name = "classifications")
public class Classification extends  BaseEntity{
    private ClassificationEnum classificationName;
    private String description;
private List<Task> tasks;
    public Classification() {
    }
@OneToMany( mappedBy = "classification",
        orphanRemoval = true,
        cascade = CascadeType.ALL)
    public List<Task> getTasks() {
        return tasks;
    }

    public void setTasks(List<Task> tasks) {
        this.tasks = tasks;
    }

    @Enumerated(EnumType.STRING)
    public ClassificationEnum getClassificationName() {
        return classificationName;
    }

    public void setClassificationName(ClassificationEnum classificationName) {
        this.classificationName = classificationName;
    }

    public String getDescription() {
        return description;
    }

    public void setDescription(String description) {
        this.description = description;
    }
}
