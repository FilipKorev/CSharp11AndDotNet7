using LoginProject;
using System.Text.RegularExpressions;


SeedLoginDb s = new SeedLoginDb();
s.Seed();


LoginOrCreateUser.Login();


