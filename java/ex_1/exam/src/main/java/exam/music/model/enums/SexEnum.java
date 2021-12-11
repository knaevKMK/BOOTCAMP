package exam.music.model.enums;

public enum SexEnum {
    MALE("Male"),
    FEMALE("Female"),
    ;
private String name;
    SexEnum(String name) {
        this.name=name;
    }

    public String getName() {
        return name;
    }
}
