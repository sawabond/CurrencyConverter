import React from 'react';

export default function CurrencyRow(props) {
  const {
    currencyOptions,
    selectedCurrency,
    onChangeCurrency,
    onChangeAmount,
    amount,
  } = props;

  function roundToHundreads(number) {
    return Math.floor(number * 100) / 100;
  }
  // function fixMinusValue(number) {
  //   return Math.abs(number);
  // }

  return (
    <div>
      <input
        type="number"
        className="input"
        value={roundToHundreads(amount)}
        onChange={onChangeAmount}
      />
      <select value={selectedCurrency} onChange={onChangeCurrency}>
        {currencyOptions.map((option) => (
          <option key={option} value={option}>
            {option}
          </option>
        ))}
      </select>
    </div>
  );
}
