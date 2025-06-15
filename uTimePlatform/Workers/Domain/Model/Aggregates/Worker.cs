using uTimePlatform.IAM.Domain.Model.Aggregates;
using uTimePlatform.Workers.Domain.Model.Commands;
using uTimePlatform.Workers.Domain.Model.ValueObjects;

namespace uTimePlatform.Workers.Domain.Model.Aggregates;

public class Worker {
    private int id;
    private String name;
    private String specialization;
    private String photoUrl;

    public Worker(int id, String name, String specialization, String photoUrl) {
        this.id = id;
        this.name = name;
        this.specialization = specialization;
        this.photoUrl = photoUrl;
    }

    public int getId() { return id; }
    public String getName() { return name; }
    public String getSpecialization() { return specialization; }
    public String getPhotoUrl() { return photoUrl; }

    public void setName(String name) { this.name = name; }
    public void setSpecialization(String specialization) { this.specialization = specialization; }
    public void setPhotoUrl(String photoUrl) { this.photoUrl = photoUrl; }
    
    public Worker(CreateWorkerCommand command)
    {
        name = command.name;
        specialization = command.specialization;
        photoUrl = command.photoUrl;
    }
}