CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" TEXT NOT NULL CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY,
    "ProductVersion" TEXT NOT NULL
);

CREATE TABLE "Sexos" (
    "SexoId" INTEGER NOT NULL CONSTRAINT "PK_Sexos" PRIMARY KEY AUTOINCREMENT,
    "Descricao" VARCHAR(15) NULL
);

CREATE TABLE "Usuarios" (
    "UserId" INTEGER NOT NULL CONSTRAINT "PK_Usuarios" PRIMARY KEY AUTOINCREMENT,
    "Nome" VARCHAR NULL,
    "DataNascimento" DATE NULL,
    "Email" VARCHAR NULL,
    "Senha" VARCHAR NULL,
    "Ativo" BIT NOT NULL DEFAULT 1,
    "SexoId" INTEGER NOT NULL,
    CONSTRAINT "FK_Usuarios_Sexos_SexoId" FOREIGN KEY ("SexoId") REFERENCES "Sexos" ("SexoId") ON DELETE CASCADE
);

CREATE INDEX "IX_Usuarios_SexoId" ON "Usuarios" ("SexoId");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20200405015846_init', '3.1.3');


INSERT INTO "Sexos" VALUES ('1', 'MASCULINO');
INSERT INTO "Sexos" VALUES ('2', 'FEMININO');

