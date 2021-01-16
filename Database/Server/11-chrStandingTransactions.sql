DROP TABLE IF EXISTS `chrStandingTransactions`;

CREATE TABLE `chrStandingTransactions` (
	`eventID` INT UNSIGNED NOT NULL,
	`fromID` INT UNSIGNED NOT NULL,
	`toID` INT UNSIGNED NOT NULL,
	`eventDateTime` BIGINT UNSIGNED NOT NULL,
	`direction` INT UNSIGNED NOT NULL,
	`eventTypeID` INT UNSIGNED NOT NULL,
	`msg` INT UNSIGNED NOT NULL,
	`modification` DOUBLE UNSIGNED NOT NULL,
	`int_1` INT UNSIGNED NOT NULL,
	`int_2` INT UNSIGNED NOT NULL,
	`int_3` INT UNSIGNED NOT NULL,
	PRIMARY KEY (`eventID`, `fromID`, `toID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
