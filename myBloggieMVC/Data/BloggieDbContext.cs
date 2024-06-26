﻿using Microsoft.EntityFrameworkCore;
using myBloggieMVC.Models.Domain;

namespace Bloggie.Web.Data
{
	public class BloggieDbContext : DbContext
	{
		public BloggieDbContext(DbContextOptions<BloggieDbContext> options) : base(options)
		{
		}

		public DbSet<BlogPost> BlogPosts { get; set; }
		public DbSet<Tag> Tags { get; set; }

	}
}
