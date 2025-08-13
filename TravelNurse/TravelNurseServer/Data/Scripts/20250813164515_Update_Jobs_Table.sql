START TRANSACTION;

ALTER TABLE "Jobs" DROP COLUMN "ClientManagerId";

ALTER TABLE "Jobs" DROP COLUMN "IsFellowshipRequired";

ALTER TABLE "Jobs" DROP COLUMN "IsNoContractInHandOnCreation";

ALTER TABLE "Jobs" DROP COLUMN "LastSyncToSense";

ALTER TABLE "Jobs" DROP COLUMN "SyncToSense";

COMMIT;

