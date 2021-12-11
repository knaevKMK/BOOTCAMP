package exam.music.model.service;

import exam.music.model.enums.ClassificationEnum;
import exam.music.model.enums.ProgressEnum;
import exam.music.model.view.UserViewModel;

import java.time.LocalDate;
import java.time.LocalDateTime;

public class TaskServiceModel {
    private String name;
    private String description;
    private LocalDate dueDate;
    private ClassificationEnum classificationEnum;
    private ProgressEnum progressEnum;
    private UserViewModel userViewModel;

    public TaskServiceModel() {
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getDescription() {
        return description;
    }

    public void setDescription(String description) {
        this.description = description;
    }

    public LocalDate getDueDate() {
        return dueDate;
    }

    public void setDueDate(LocalDate dueDate) {
        this.dueDate = dueDate;
    }

    public ClassificationEnum getClassificationEnum() {
        return classificationEnum;
    }

    public void setClassificationEnum(ClassificationEnum classificationEnum) {
        this.classificationEnum = classificationEnum;
    }

    public ProgressEnum getProgressEnum() {
        return progressEnum;
    }

    public void setProgressEnum(ProgressEnum progressEnum) {
        this.progressEnum = progressEnum;
    }

    public UserViewModel getUserViewModel() {
        return userViewModel;
    }

    public void setUserViewModel(UserViewModel userViewModel) {
        this.userViewModel = userViewModel;
    }
}
