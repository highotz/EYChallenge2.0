﻿namespace EYChallenge2._0.ViewModel.User
{
    public class InsertUserViewModel
    {
        public string name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public List<string> mandatorySkills { get; set; }

        public List<string> softSkills { get; set; }
    }
}
