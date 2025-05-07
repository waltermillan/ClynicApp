CREATE TABLE `Appointments` (
  `id` int NOT NULL AUTO_INCREMENT,
  `date` date NOT NULL,
  `id_patient` int NOT NULL,
  `id_doctor` int NOT NULL,
  `id_staff` int NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;