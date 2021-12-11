package exam.music.model.binding;

import exam.music.model.enums.ClassificationEnum;
import org.hibernate.validator.constraints.Length;

import javax.validation.constraints.FutureOrPresent;
import javax.validation.constraints.NotBlank;
import javax.validation.constraints.NotEmpty;
import javax.validation.constraints.NotNull;
import java.time.LocalDate;
import java.time.LocalDateTime;

public class TaskBindingModel {
    private String name;
    private String description;
    private String dueDate;
    private ClassificationEnum classification;

    public TaskBindingModel() {
    }

    @NotNull(message = "Name can not be null")
    @NotEmpty(message = "Name can not be empty")
    @NotBlank(message = "Name can not be blank")
    @Length(min = 3, max = 20, message = "Name length must be between 3 and 20 characters ")
    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    @NotNull(message = "Description can not be null")
    @NotEmpty(message = "Description can not be empty")
    @NotBlank(message = "Description can not be blank")
    @Length(min = 3, message = "Description length must be min 3 characters ")
    public String getDescription() {
        return description;
    }

    public void setDescription(String description) {
        this.description = description;
    }
    @NotNull(message = "Date can not be null")
//    @FutureOrPresent(message = "Date can not be in the Past")
    public String getDueDate() {
        return dueDate;
    }

    public void setDueDate(String dueDate) {
        this.dueDate = dueDate;
    }

    @NotNull(message = "Classification can not be null")
    public ClassificationEnum getClassification() {
        return classification;
    }

    public void setClassification(ClassificationEnum classification) {
        this.classification = classification;
    }
}
