START TRANSACTION;

ALTER TABLE "Jobs" DROP COLUMN "PlatformJobId";

ALTER TABLE "Jobs" ADD "PlatformId" integer;

COMMIT;

