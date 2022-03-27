import React from 'react';

function Footer() {
  return (
    <>
      <div>
        <hr />

        <p>
          Copyright &copy; {new Date().getFullYear()} Oleksandr Bondarenko,
          Danylo Dovhopolyi, Ruslan Tretiakov
        </p>
      </div>
    </>
  );
}

export default Footer;
