using LoginProject;


SeedLoginDb s = new SeedLoginDb();
s.Seed();


LoginOrCreateUser.Login();


