DROP TABLE IF EXISTS `chrStandingTransactions`;

CREATE TABLE `chrStandingTransactions` (
	`eventID` INT(10) UNSIGNED NOT NULL AUTO_INCREMENT,
	`fromID` INT(10) UNSIGNED NOT NULL,
	`toID` INT(10) UNSIGNED NOT NULL,
	`eventDateTime` BIGINT(20) UNSIGNED NOT NULL,
	`direction` INT(10) UNSIGNED NOT NULL,
	`eventTypeID` INT(10) UNSIGNED NOT NULL,
	`msg` TEXT NOT NULL,
	`modification` DOUBLE NOT NULL,
	`int_1` INT(10) UNSIGNED NOT NULL,
	`int_2` INT(10) UNSIGNED NOT NULL,
	`int_3` INT(10) UNSIGNED NOT NULL,
	PRIMARY KEY (`eventID`, `fromID`, `toID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
