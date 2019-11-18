package Task3.WebService.Task3.repository;

import Task3.WebService.Task3.model.Speaker;
import org.springframework.data.jpa.repository.JpaRepository;

public interface SpeakerRepository extends JpaRepository<Speaker, Long> {
}