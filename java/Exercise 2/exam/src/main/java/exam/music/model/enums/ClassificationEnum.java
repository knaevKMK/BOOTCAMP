package exam.music.model.enums;

public enum ClassificationEnum {
    BUG("Bug"), FEATURE("Feature"), SUPPORT("Support"), OTHER("Other");
    private String name;

    ClassificationEnum(String name) {
        this.name = name;
    }

    public String getName() {
        return name;
    }
}
