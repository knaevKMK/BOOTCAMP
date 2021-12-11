package exam.music.model.enums;

public enum ProgressEnum {

    OPEN("Open"),
    IN_PROGRESS("In Progress"),
    COMPLETED("Completed"),
    OTHER("Other");

    private String name;

    ProgressEnum(String name) {
        this.name = name;
    }

    public String getName() {
        return name;
    }
}
