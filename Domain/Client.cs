﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Domain
{
	public class Client
	{
		public int Id { get; set; }
		public string name { get; set; }

		public string password { get; set; }
		public virtual ICollection<Figure> figures { get; set; }
		public virtual ICollection<Material> materials { get; set; }
		public virtual ICollection<Model> models { get; set; }
		public virtual ICollection<Scene> scenes { get; set; }



		public Client()
		{
			this.name = "";
			this.password = "";
		}


		public Client(string name, string password)
		{
			this.name = name;
			this.password = password;
		}

		public bool VerifyName(string name)
		{
			if (name == "")
			{

				throw new EmptyUserNameException();

			}
			if (name.Length < 3 || name.Length > 20 || !Regex.IsMatch(name, @"^\S+$"))
			{
				return false;
			}
			bool hasNumber = false;
			bool hasLetter = false;
			foreach (char c in name)
			{
				if (char.IsDigit(c))
				{
					hasNumber = true;
				}
				if (char.IsLetter(c))
				{
					hasLetter = true;
				}
			}
			return hasNumber && hasLetter;
		}

		public bool VerifyPassword(string password)
		{
			if (password == "")
			{
				throw new EmptyUserNameException();
			}
			if (password.Length < 5 || password.Length > 25)
			{
				return false;
			}
			bool hasUpperCase = false;
			bool hasNumber = false;
			foreach (char c in password)
			{
				if (char.IsUpper(c))
				{
					hasUpperCase = true;
				}
				if (char.IsDigit(c))
				{
					hasNumber = true;
				}
			}
			return hasNumber && hasUpperCase;
		}

		public bool MatchingPassword(string password)
		{

			if (password.Length != this.password.Length)
			{
				return false;
			}
			for (int i = 0; i < password.Length; i++)
			{
				if (password[i] != this.password[i])
				{
					return false;
				}
			}
			return true;
		}

		public bool MatchingUsername(string name)
		{


			if (name.Length != this.name.Length)
			{
				return false;
			}
			for (int i = 0; i < name.Length; i++)
			{
				if (name[i] != this.name[i])
				{
					return false;
				}
			}
			return true;
		}

		public bool VerifyDate(DateTime date)
		{

			DateTime dateNow = DateTime.Now;

			if (DateTime.Compare(dateNow, date) > 0)
			{

				return true;
			}

			return false;
		}
	}
}