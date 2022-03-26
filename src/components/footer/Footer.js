import React from "react";

function Footer() {
  return (
    <>
      <p
        style={{
          position: "absolute",
          bottom: "0",
          width: "90%",
          textAlign: "center",
        }}
      >
        <hr />
        Copyright &copy; {new Date().getFullYear()} Oleksandr Bondarenko, Danylo
        Dovhopolyi, Tretiakov Ruslan
      </p>
    </>
  );
}

export default Footer;
