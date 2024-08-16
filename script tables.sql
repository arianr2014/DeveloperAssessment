
CREATE TABLE `donors` (
  `donorID` int(11) NOT NULL AUTO_INCREMENT,
  `donorName` varchar(255) NOT NULL,
  `address` varchar(255) DEFAULT NULL,
  `activeStatus` tinyint(1) DEFAULT 1,
  PRIMARY KEY (`donorID`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

CREATE TABLE `pledges` (
  `pledgeID` int(11) NOT NULL AUTO_INCREMENT,
  `donorID` int(11) DEFAULT NULL,
  `pledgeDate` date NOT NULL,
  `pledgeAmount` decimal(10,2) NOT NULL,
  PRIMARY KEY (`pledgeID`),
  KEY `donorID` (`donorID`),
  CONSTRAINT `pledges_ibfk_1` FOREIGN KEY (`donorID`) REFERENCES `donors` (`donorID`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
CREATE TABLE `payments` (
  `paymentID` int(11) NOT NULL AUTO_INCREMENT,
  `donorID` int(11) DEFAULT NULL,
  `paymentDate` date NOT NULL,
  `paymentAmount` decimal(10,2) NOT NULL,
  PRIMARY KEY (`paymentID`),
  KEY `donorID` (`donorID`),
  CONSTRAINT `payments_ibfk_1` FOREIGN KEY (`donorID`) REFERENCES `donors` (`donorID`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

CREATE TABLE `pledgepayments` (
  `pledgeID` int(11) NOT NULL,
  `paymentID` int(11) NOT NULL,
  PRIMARY KEY (`pledgeID`,`paymentID`),
  KEY `paymentID` (`paymentID`),
  CONSTRAINT `pledgepayments_ibfk_1` FOREIGN KEY (`pledgeID`) REFERENCES `pledges` (`pledgeID`),
  CONSTRAINT `pledgepayments_ibfk_2` FOREIGN KEY (`paymentID`) REFERENCES `payments` (`paymentID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

CREATE TABLE `changelog` (
  `changelogID` int(11) NOT NULL AUTO_INCREMENT,
  `changeDate` timestamp NOT NULL DEFAULT current_timestamp(),
  `changeDescription` text NOT NULL,
  PRIMARY KEY (`changelogID`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
