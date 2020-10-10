﻿using System.ComponentModel.DataAnnotations;

namespace Api.Models
{
    public class DbConnectionSetup
    {
        [StringLength(100)]
        public string Hostname { get; set; }
        [StringLength(100)]
        public string Database { get; set; }
        [StringLength(20)]                
        public string Port { get; set; }        
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [StringLength(100)]
        public string UserId { get; set; }
        public override string ToString()
        {
            return $"User ID={this.UserId};Password={this.Password};Host={this.Hostname};Port={this.Port};Database={this.Database};Pooling=true;";
        }
    }
}