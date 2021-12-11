package exam.music.model.entity;


import exam.music.model.enums.SexEnum;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Enumerated;
import javax.persistence.Table;

@Entity
@Table(name = "sex")
public class SexEntity extends BaseEntity {
    private SexEnum sexEnum;
    private String name;

    public SexEntity() {
    }

    @Enumerated
    public SexEnum getSexEnum() {
        return sexEnum;
    }

    public void setSexEnum(SexEnum sexEnum) {
        this.sexEnum = sexEnum;
    }

    @Column(nullable = false)
    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }
}
