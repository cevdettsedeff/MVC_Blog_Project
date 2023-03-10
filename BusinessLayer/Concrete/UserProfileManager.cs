using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class UserProfileManager
    {
        Repository<Author> repoUser = new Repository<Author> ();

        Repository<Blog> repoUserBlog = new Repository<Blog>();

        public List<Author> GetAuthorByMail(string p)
        {
            return repoUser.List(x => x.AuthorMail == p);
        }

        public List<Blog> GetBlogByAuthor(int id)
        {
            return repoUserBlog.List(x => x.AuthorID == id);
        }

        public void EditAuthor(Author p)
        {
            Author author = repoUser.Find(x => x.AuthorID == p.AuthorID);
            author.AuthorName = p.AuthorName;
            author.AuthorImage = p.AuthorImage;
            author.AuthorAbout = p.AuthorAbout;
            author.AuthorTitle = p.AuthorTitle;
            author.AboutShort = p.AboutShort;
            author.AuthorMail = p.AuthorMail;
            author.AuthorPassword = p.AuthorPassword;
            author.AuthorPhoneNumber = p.AuthorPhoneNumber;
           
            repoUser.Update(author);
        }

    }
}
