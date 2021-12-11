package exam.music.model.enums;

public enum CategoryEnum {
    SHIRT("Shirt"),
    DENIM("Denim"),
    SHORTS("Shorts"),
    JACKET("Jacket");

    private String name;
    CategoryEnum(String name) {
        this.name=name;
    }

    public String getName() {
        return this.name;
    }
}
