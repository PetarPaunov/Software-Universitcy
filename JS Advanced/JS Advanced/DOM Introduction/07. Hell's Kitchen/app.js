function solve() {
  document.querySelector("#btnSend").addEventListener("click", onClick);

  function onClick() {
    let input = document.querySelector("#inputs textarea").value;
    input = JSON.parse(input);
    let restorants = {};
    let avrageSalaty = 0;
    let curentAvrageSalary = 0;
    let totalSalary = 0;
    let bestName = "";

    for (const items of input) {
      let restorantsInfo = items.split(" - ");
      let restorantName = restorantsInfo.shift();
      let workrsData = restorantsInfo[0].split(", ");

      for (const items of workrsData) {
        let [name, salary] = items.split(" ");
        if (!restorants.hasOwnProperty(restorantName)) {
          restorants[restorantName] = {};
        }
        salary = Number(salary);
        restorants[restorantName][name] = salary;
      }
    }

    let entrys = Object.entries(restorants);
    for (const enty of entrys) {
      let key = enty[0];
      let valuse = Object.values(enty[1]);

      for (const value of valuse) {
        totalSalary += value;
      }
      avrageSalaty = totalSalary / valuse.length;

      if (avrageSalaty > curentAvrageSalary) {
        curentAvrageSalary = avrageSalaty;
        bestName = key;
        totalSalary = 0;
      }
    }

    let result = Object.entries(restorants[bestName]).sort(
      (a, b) => b[1] - a[1]
    );
    let print = "";
    result.forEach((w) => (print += `Name: ${w[0]} With Salary: ${w[1]} `));

    document.querySelector(
      "#bestRestaurant p"
    ).textContent = `Name: ${bestName} Average Salary: ${curentAvrageSalary.toFixed(2)} Best Salary: ${(result[0][1]).toFixed(2)}`;

    document.querySelector("#workers p ").textContent = print;
  }
}
