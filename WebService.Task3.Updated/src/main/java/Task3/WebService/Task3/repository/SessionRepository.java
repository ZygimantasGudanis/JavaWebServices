package Task3.WebService.Task3.repository;

import Task3.WebService.Task3.model.Session;
import org.springframework.data.jpa.repository.JpaRepository;

public interface SessionRepository extends JpaRepository<Session, Long> {
}