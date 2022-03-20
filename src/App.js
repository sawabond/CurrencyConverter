import React, { useEffect, useState } from "react";
import "./App.css";
import CurrencyRow from "./CurrencyRow";

const URL = "https://api.exchangerate.host/latest";
const API_CALL_TIMESTAMP = 1000 * 60 * 10; // 10 minutes

function App() {
  const [currencyOptions, setCurrencyOptions] = useState([]);
  const [fromCurrency, setFromCurrency] = useState();
  const [toCurrency, setToCurrency] = useState();
  const [exchangeRate, setExchangeRate] = useState();
  const [amount, setAmount] = useState(1);
  const [amountInFromCurrency, setAmountInFromCurrency] = useState(true);

  let toAmount, fromAmount;
  if (amountInFromCurrency) {
    fromAmount = amount;
    toAmount = amount * exchangeRate;
  } else {
    toAmount = amount;
    fromAmount = amount / exchangeRate;
  }
  function currencyApiCall() {
    fetch(URL)
      .then((res) => res.json())
      .then((data) => {
        data.base = "USD";
        const firstCurrency = Object.keys(data.rates)[0];
        setCurrencyOptions([data.base, ...Object.keys(data.rates)]);
        setFromCurrency(data.base);
        setToCurrency(firstCurrency);
        setExchangeRate(data.rates[firstCurrency]);
      });
  }
  useEffect(() => {
    currencyApiCall();
    setInterval(currencyApiCall, API_CALL_TIMESTAMP);
  }, []);

  useEffect(() => {
    if (fromCurrency !== null && toCurrency !== null) {
      fetch(`${URL}?base=${fromCurrency}&symbols=${toCurrency}`)
        .then((res) => res.json())
        .then((data) => setExchangeRate(data.rates[toCurrency]));
    }
  }, [fromCurrency, toCurrency]);

  function handleFromAmountChange(e) {
    setAmount(e.target.value);
    setAmountInFromCurrency(true);
  }
  function handleToAmountChange(e) {
    setAmount(e.target.value);
    setAmountInFromCurrency(false);
  }

  return (
    <>
      <h1>Convert</h1>
      <CurrencyRow
        currencyOptions={currencyOptions}
        selectedCurrency={fromCurrency}
        onChangeCurrency={(e) => setFromCurrency(e.target.value)}
        onChangeAmount={handleFromAmountChange}
        amount={fromAmount}
      />
      <div className="equals">=</div>
      <CurrencyRow
        currencyOptions={currencyOptions}
        selectedCurrency={toCurrency}
        onChangeCurrency={(e) => setToCurrency(e.target.value)}
        onChangeAmount={handleToAmountChange}
        amount={toAmount}
      />
    </>
  );
}

export default App;
