CREATE TABLE `settings`
(
    `id`       int(11)             NOT NULL AUTO_INCREMENT,
    `guild_id` bigint(20) unsigned NOT NULL,
    `key`      varchar(64)         NOT NULL,
    `value`    text                NOT NULL,
    PRIMARY KEY (`id`)
) ENGINE = InnoDB
  AUTO_INCREMENT = 2
  DEFAULT CHARSET = utf8mb4;