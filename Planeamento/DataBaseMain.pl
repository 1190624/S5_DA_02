%cityByID(?CityName, ?ID).
cityByID('Tomar', 11).
cityByID('Espinho', 23).
cityByID('Coimbra', 12).
cityByID('Ovar', 4).
cityByID('Caminha', 412).
cityByID('Olhão',1).

%mainCity(?ID).
mainCity(412).

%truckData(?Name, ?Tare, ?CargoCapacity, ?BateryMax, ?Autonomie, ?RechargeTime).
truckData('Tec', 2311, 412, 100, 124, 60).

%deliveryData(?ID, ?Date, ?Weight, ?WarehouseID, ?PlacementTime, ?RemovalTime).
deliveryData(2311, 4122022, 11, 23, 4, 12).
deliveryData(1123, 4122022, 23, 11, 12, 4).
deliveryData(412, 4122022, 12, 4, 23, 11).
deliveryData(4439, 20221205, 200, 1, 8, 10).
deliveryData(4438, 20221205, 150, 12, 7, 9).

%travelTime(?CityAID, ?CityBID, ?Time).
travelTime(11, 23, 231).
travelTime(11, 12, 411).
travelTime(11, 4, 161).
travelTime(11, 412, 411).
travelTime(11, 1, 123).
travelTime(23, 11, 231).
travelTime(23, 12, 168).
travelTime(23, 4, 612).
travelTime(23, 412, 241).
travelTime(23, 1, 123).
travelTime(12, 11, 141).
travelTime(12, 23, 168).
travelTime(12, 4, 162).
travelTime(12, 412, 22).
travelTime(12, 1, 123).
travelTime(4, 11, 235).
travelTime(4, 23, 205).
travelTime(4, 12, 72).
travelTime(4, 412, 91).
travelTime(4, 1, 123).
travelTime(412, 11, 234).
travelTime(412, 23, 241).
travelTime(412, 12, 22).
travelTime(412, 4, 91).
travelTime(412, 1, 123).
travelTime(1, 11, 123).
travelTime(1, 23, 123).
travelTime(1, 12, 123).
travelTime(1, 4, 123).
travelTime(1, 412, 123).

%travelConsumption(?CityAID, ?CityBID, ?Energy).
travelConsumption(11, 23, 11).
travelConsumption(11, 12, 4).
travelConsumption(11, 4, 41).
travelConsumption(11, 412, 86).
travelConsumption(11, 1, 113).
travelConsumption(23, 11, 11).
travelConsumption(23, 12, 16).
travelConsumption(23, 4, 44).
travelConsumption(23, 412, 2311).
travelConsumption(23, 1, 113).
travelConsumption(12, 11, 4).
travelConsumption(12, 23, 16).
travelConsumption(12, 4, 54).
travelConsumption(12, 412, 16).
travelConsumption(12, 1, 113).
travelConsumption(4, 11, 41).
travelConsumption(4, 23, 44).
travelConsumption(4, 12, 54).
travelConsumption(4, 412, 34).
travelConsumption(4, 1, 113).
travelConsumption(412, 11, 86).
travelConsumption(412, 23, 2311).
travelConsumption(412, 12, 16).
travelConsumption(412, 4, 34).
travelConsumption(412, 1, 11).
travelConsumption(1, 11, 11).
travelConsumption(1, 23, 11).
travelConsumption(1, 12, 11).
travelConsumption(1, 4, 11).
travelConsumption(1, 412, 11).

%truckStopList(+ListDeliveriesID, -ListStopsID)
truckStopList([], []).

truckStopList([Head|Tail], ListStopsID):-
    truckStopList(Tail, TempList),
    deliveryData(Head, _, _, WarehouseID, _, _),
    append([WarehouseID], TempList, ListStopsID).

%weightPerStop(+ListStopsID, +ListDeliveriesID, -ListWeigths)
weightPerStop(ListStopsID, ListDeliveriesID, ListWeigths):-
    weightPerStopAcc(ListStopsID, ListDeliveriesID, ListWeigths, _).

%weightPerStopAcc(+ListStopsID, +ListDeliveriesID, -ListWeigths, +Acc)
weightPerStopAcc([], [], [0], 0).

weightPerStopAcc([_|Tail1], [Head2|Tail2], [Acc|Tail3], Acc):-
    weightPerStopAcc(Tail1, Tail2, Tail3, TempVar),
    deliveryData(Head2, _, Weight, _, _, _),
    Acc is TempVar + Weight.

%calcTotalWeight(+ListWeigths, +TruckName, -ListTotalWeight)
calcTotalWeight([], _, []).

calcTotalWeight([Head1|Tail1], TruckName, [TotalWeight|Tail2]):-
    calcTotalWeight(Tail1, TruckName, Tail2),
    truckData(TruckName, Tare, _, _, _, _),
    TotalWeight is Tare + Head1.

%routeTravelTimeAlt(+TruckName, +CurrCap, +Route, +WeightList, +ListUnloadingTime, -TravelTime)
routeTravelTime(_, _, [_|[]], [], [], 0).

routeTravelTime(TruckName, CurrCap, [Head1A, Head1B|Tail1], [Head2|Tail2], [Head3|Tail3], TravelTime):-
    calcTruckMaxWeight(TruckName, TruckMaxWeight),
    calcEnergyConsumed(Head1A, Head1B, TruckMaxWeight, Head2, EnergyConsumed),
    EnergyLeft is CurrCap - EnergyConsumed,
    minTruckEnergy(TruckName, MinEnergy),
    EnergyLeft >= MinEnergy,
    calcTravelTime(Head1A, Head1B, TruckMaxWeight, Head2, ElapsedTime),
    routeTravelTime(TruckName, EnergyLeft, [Head1B|Tail1], Tail2, Tail3, TempVar1),
    TempVar2 is TempVar1 + ElapsedTime,
    TravelTime is Head3 + TempVar2.

routeTravelTime(TruckName, CurrCap, [Head1A, Head1B|Tail1], [Head2|Tail2], [Head3|Tail3], TravelTime):-
    calcTruckMaxWeight(TruckName, TruckMaxWeight),
    calcEnergyConsumed(Head1A, Head1B, TruckMaxWeight, Head2, EnergyConsumed),
    EnergyLeft1 is CurrCap - EnergyConsumed,
    minTruckEnergy(TruckName, MinEnergy),
    EnergyLeft1 < MinEnergy,
    maxTruckEnergy(TruckName, MaxEnergy),
    EnergyConsumed =< MaxEnergy,
    TempVar1 is EnergyConsumed + MinEnergy,
    RechargeEnergy is TempVar1 - CurrCap,
    calcRechargeTime(TruckName, MaxEnergy, MinEnergy, RechargeEnergy, RechargeTime),
    TempVar2 is CurrCap + RechargeEnergy,
    EnergyLeft2 is TempVar2 - EnergyConsumed,
    calcTravelTime(Head1A, Head1B, TruckMaxWeight, Head2, ElapsedTime),
    routeTravelTime(TruckName, EnergyLeft2, [Head1B|Tail1], Tail2, Tail3, TempVar3),
    TempVar4 is TempVar3 + ElapsedTime,
    TempVar5 is TempVar4 + RechargeTime,
    TravelTime is Head3 + TempVar5.

%minTruckEnergy(+TruckName, -Result)
minTruckEnergy(TruckName, Result):-
    truckData(TruckName, _, _, MaxCap, _, _),
    TempVar is MaxCap * 20,
    Result is TempVar / 100. 

%maxTruckEnergy(+TruckName, -Result)
maxTruckEnergy(TruckName, Result):-
    truckData(TruckName, _, _, MaxCap, _, _),
    TempVar is MaxCap * 80,
    Result is TempVar / 100.

%calcRechargeTime(+TruckName, +MaxEnergy, +MinEnergy, +RechargeEnergy, -Result)
calcRechargeTime(TruckName, MaxEnergy, MinEnergy, RechargeEnergy, Result):-
    truckData(TruckName, _, _, _, _, RechargeTime),
    EnergyDiff is MaxEnergy - MinEnergy,
    TempVar is RechargeEnergy * RechargeTime,
    Result is TempVar / EnergyDiff.

%calcEnergyConsumed(+CityAID, +CityBID, +TruckMaxWeight, +Weight, -EnergyConsumed)
calcEnergyConsumed(CityAID, CityBID, TruckMaxWeight, Weight, EnergyConsumed):-
    travelConsumption(CityAID, CityBID, Energy),
    TempVar is Weight * Energy,
    EnergyConsumed is TempVar / TruckMaxWeight.

%calcTruckMaxWeight(+TruckName, -Result)
calcTruckMaxWeight(TruckName, Result):-
    truckData(TruckName, Tare, CargoCapacity, _, _, _),
    Result is Tare + CargoCapacity.

%calcTravelTime(+CityAID, +CityBID, +TruckMaxWeight, +Weight, -ElapsedTime)
calcTravelTime(CityAID, CityBID, TruckMaxWeight, Weight, ElapsedTime):-
    travelTime(CityAID, CityBID, Time),
    TempVar is Weight * Time,
    ElapsedTime is TempVar / TruckMaxWeight.

%routeUnloadingTime(+ListDeliveriesID, -ListUnloadingTime)
routeUnloadingTime([], [0]).

routeUnloadingTime([Head|Tail], ListUnloadingTime):-
    routeUnloadingTime(Tail, TempList),
    deliveryData(Head, _, _, _, _, UnloadingTime),
    append([UnloadingTime], TempList, ListUnloadingTime).

%allRoutesTravelTime(+TruckName, +ListDeliveriesID, -RouteList, -TravelTimeList)
allRoutesTravelTime(TruckName, ListDeliveriesID, RouteList, TravelTimeList):-
    truckStopList(ListDeliveriesID, ListStopsID),
    weightPerStop(ListStopsID, ListDeliveriesID, ListWeigths),
    calcTotalWeight(ListWeigths, TruckName, ListTotalWeight),
    findall(PermListStopsID, permutation(ListStopsID, PermListStopsID), AllPermStopsID),
    completeAllRoutes(AllPermStopsID, TempList1),
    truckData(TruckName, _, _, MaxCap, _, _),
    routeUnloadingTime(ListDeliveriesID, ListUnloadingTime),
    eachRouteTravelTime(TruckName, MaxCap, TempList1, ListTotalWeight, ListUnloadingTime, TempList2, RouteList),
    addPackageLoadingTime(ListDeliveriesID, TempList2, TravelTimeList).

%completeAllRoutes(+AllPermStopsID, -RouteList)
completeAllRoutes([], []).

completeAllRoutes([Head1|Tail1], [Head2|Tail2]):-
    completeAllRoutes(Tail1, Tail2),
    mainCity(CityID),
    append([CityID], Head1, TempList),
    append(TempList, [CityID], Head2).

%eachRouteTravelTime(+TruckName, +CurrCap, +RouteList, +ListTotalWeight, +ListUnloadingTime, -TravelTimeList, -PossibleRoutes)
eachRouteTravelTime(_, _, [], _, _, [], []).

eachRouteTravelTime(TruckName, CurrCap, [Head1|Tail1], ListTotalWeight,  ListUnloadingTime, [Head2|Tail2], [Head1|Tail3]):-
    routeTravelTime(TruckName, CurrCap, Head1, ListTotalWeight, ListUnloadingTime, Head2),
    !,
    eachRouteTravelTime(TruckName, CurrCap, Tail1, ListTotalWeight, ListUnloadingTime, Tail2, Tail3).

eachRouteTravelTime(TruckName, CurrCap, [_|Tail], ListTotalWeight,  ListUnloadingTime, TravelTimeList, PossibleRoutes):-
    eachRouteTravelTime(TruckName, CurrCap, Tail, ListTotalWeight, ListUnloadingTime, TravelTimeList, PossibleRoutes).

%addPackageLoadingTime(+ListDeliveriesID, +TravelTimeList, -UpdatedTimeList)
addPackageLoadingTime(_, [], []).

addPackageLoadingTime(ListDeliveriesID, [Head1|Tail1], [Head2|Tail2]):-
    calcPackageLoadingTime(ListDeliveriesID, LoadingTime),
    Head2 is Head1 + LoadingTime,
    addPackageLoadingTime(ListDeliveriesID, Tail1, Tail2).

%calcPackageLoadingTime(+ListDeliveriesID, +TravelTime, -UpdatedTravelTime)
calcPackageLoadingTime([], 0).

calcPackageLoadingTime([Head|Tail], Result):-
    calcPackageLoadingTime(Tail, TempVar),
    deliveryData(Head, _, _, _, PlacementTime, _),
    Result is TempVar + PlacementTime.
