﻿using System.Collections.Generic;
using System.Linq;
using Lab2.Models;

namespace Lab2.Repositories
{
    public class BookRepository
    {
        public static Book GetBookById(int id)
        {
            // Get a collection a books
            var bookList = GetAllBookData();

            // Get the book with the given id
            return bookList.FirstOrDefault(book => book.Id == id);
        }

        public static List<Book> GetAllBookData()
        {
            // Define the model data for each book
            var bookList = new List<Book>
            {
                new Book
                {
                    Id = 0001,
                    Title = "Object Oriented Programming in C#",
                    Description =
                        "All managed languages in the .NET Framework, such as Visual Basic and C#, provide full support for object-oriented programming including encapsulation, inheritance, and polymorphism. Encapsulation means that a group of related properties, methods, and other members are treated as a single unit or object. Inheritance describes the ability to create new classes based on an existing class.",
                    Price = 45.5
                },
                new Book
                {
                    Id = 0002,
                    Title = "Web Programming in PHP",
                    Description =
                        "The PHP development team announces the immediate availability of PHP 5.6.0beta1. This release adds new features and fixes bugs and marks the feature freeze for the PHP 5.6.0 release. All users of PHP are encouraged to test this version carefully, and report any bugs in the bug tracking system.",
                    Price = 24.9
                },
                new Book
                {
                    Id = 0003,
                    Title = "ASP.NET Web Application Development",
                    Description =
                        "This article gives you an overview of programming with ASP.NET Web Pages using the Razor syntax. ASP.NET is Microsoft's technology for running dynamic web pages on web servers. This articles focuses on using the C# programming language.",
                    Price = 30.0
                },
                new Book
                {
                    Id = 0004,
                    Title = "Java Programming in 21 Days",
                    Description =
                        "The Java Tutorials are practical guides for programmers who want to use the Java programming language to create applications. They include hundreds of complete, working examples, and dozens of lessons. Groups of related lessons are organized into \"trail\".",
                    Price = 37.0
                },
                new Book
                {
                    Id = 0005,
                    Title = "Advanced Database Topics",
                    Description =
                        "The goal of the course is to introduce students to modern database and data management systems. The course will be focused on efficient query processing and indexing techniques for spatial, temporal and multimedia databases. Another topic that will be covered is the analysis of large datasets (data mining). In particular, efficient and scalable algorithms for clustering, association rule discovery and classification of very large datasets will be discussed.",
                    Price = 19.9
                },
                new Book
                {
                    Id = 0006,
                    Title = "Professional JSP Programming",
                    Description =
                        "Professional JSP 2nd Edition is for professional programmers who want to use JavaServer Pages (JSP ) technology and servlets to create the web front end of their J2EE applications. No knowledge of JSP pages or servlets is required, but the reader is assumed to be familiar with the Java programming language and the core APIs.",
                    Price = 39.99
                },
                new Book
                {
                    Id = 0007,
                    Title = "Professional ASP.NET MVC",
                    Description =
                        "Microsoft insiders join giants of the software development community to offer this in-depth guide to ASP.NET MVC, an essential web development technology.",
                    Price = 54.99
                },
                new Book
                {
                    Id = 0008,
                    Title = "Web Animation with JQuery",
                    Description =
                        "The jQuery library provides several techniques for adding animation to a web page. These include simple, standard animations that are frequently used, and the ability to craft sophisticated custom effects.",
                    Price = 64.99
                },
                new Book
                {
                    Id = 0009,
                    Title = "AJAX",
                    Description =
                        "This book is a step-by-step. Each chapter contains a friendly mix of theory and practice. You'll be coding your first AJAX application at the end of the first chapter, and with each new chapter you'll develop increasingly complex AJAX applications featuring advanced techniques and coding patterns.AJAX and PHP:  coding patterns and techniques and be able to assess the security and SEO implications of their code",
                    Price = 25.99
                },
                new Book
                {
                    Id = 0010,
                    Title = "Visual Quick Start Guide",
                    Description =
                        "This book begins by showing you the basics of the XML language. Then, by building on that knowledge, additional and supporting languages and systems will be discussed. To get the most out of this book, you should be somewhat familiar with HTML, although you doneed to be an expert coder by any stretch. No other previous knowledge is required.",
                    Price = 43.99
                },
                new Book
                {
                    Id = 0011,
                    Title = "XML",
                    Description =
                        "This new edition is the comprehensive XML reference. Serious users of XML will find coverage on just about everything they need, from fundamental syntax rules, to details of DTD and XML Schema creation, to XSLT transformations, to APIs used for processing XML documents. XML in a Nutshell also covers XML 1.1, as well as updates to SAX2 and DOM Level 3 coverage. for a particular piece, XML in a Nutshell puts the information at your fingertips",
                    Price = 17.59
                },
                new Book
                {
                    Id = 0012,
                    Title = "Beginning  XML",
                    Description =
                        "Beginning XML provides a complete course in the Extensible Markup Language (XML) with an unusually gradual learning curve. In fact, the introduction states that the book is for people who know that it would be a pretty good idea to learn the language, but are not 100 percent sure why. Despite its recognition of the fuzziness of readers.",
                    Price = 65.23
                },
                new Book
                {
                    Id = 0013,
                    Title = "New Perspectives on  XML",
                    Description =
                        "Updated to teach the most current XML standards, this book uses real-world case studies and a practical, step-by-step approach to teach XML. It provides extensive coverage of DTDs, namespaces, schemas, Cascading Style Sheets, XSLT, XPath, and programming with the WSC document object model.",
                    Price = 39.99
                }
            };

            return bookList;
        }
    }
}