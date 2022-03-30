import React from 'react';
import FooterStyles from './Footer.css';

function Footer() {
  return (
    <div className="footer">
      <hr />
      <p>
        Copyright &copy; {new Date().getFullYear()} Oleksandr Bondarenko, Danylo
        Dovhopolyi, Ruslan Tretiakov
      </p>
    </div>
  );
}

export default Footer;
