# -*- coding: utf-8 -*-
"""
Created on Wed Jun  5 09:44:38 2024
länk till videoklipp: https://youtu.be/wRyxyB4ilJI
@author: Emelie Wärmlund
"""
import numpy as np
import matplotlib.pyplot as plt
#%% Uppgift 1a,b och c

t=np.array([20.5,32.7,51.0,73.2,95.7]) #initierar array för temperatur
r=np.array([765,826,873,942,1032]) #initierar array för resistens
p=np.polynomial.polynomial.polyfit(t,r,1) #beräknar anpassningsfunktion
x=np.linspace(20,100) # sätter ett grid under minimitalet och över maxtalet för temperatur
y=lambda x:p[0]+x*p[1] #beräknar y

fig, ax = plt.subplots()
plt.scatter(t,r) #skapar en skatter för datan
ax.set_xlabel('temperatur T', fontsize=14) #sätter labels på axlar
ax.set_ylabel('resistans', fontsize=14)
ax.plot(x,y(x),color='C1') #plottar linjen
plt.show()

#redovisar resultat
print('Uppskattad resistens vid temperatur 100:', round(y(100),1))
print(f'Anpassningfunktionen är: R={round(p[0],4)} + {round(p[1],4)}T') #använder stränginterpolering för att redovisa resultatet tillsammans med text

#%% Uppgift 2
#Istället fär att bygga en fysisk pendel, har jag använt denna sida för att generera data:
#https://www.myphysicslab.com/pendulum/pendulum-en.html

l=np.array([0.1,0.3,0.5,0.7,1,1.2,1.4,1.6]) #skapar array för längder
t=np.array([0.3425,0.5825,0.76,0.89,1.06,1.1825,1.27,1.37]) #skapar array för pendeltid
a0=1.08  #initierar startvärden
a1=0.5 #initierar startvärden
x=np.linspace(0,2) #sätter x grid
y=lambda x,a0,a1: a0*x**a1 #skapar funktion för y

fig, ax = plt.subplots()
plt.scatter(l,t) #skapar en skatter för datan
ax.set_xlabel('Pendellängd (m)', fontsize=14) #sätter labels på axlar
ax.set_ylabel('Periodtid (s)', fontsize=14)
ax.plot(x,y(x,a0,a1),color='C1') #plottar linjen
plt.show()

time=1 #sätter variabel time till 1 sekund
x_at_one=(time/a0)**(1/a1) #inverterar tidigare funktion för y för att beräkna x vid tid 1 sekund
print('Längd vid periodtid 1 s:',round(x_at_one,2) ) #skriver ut resultatet

#%% Uppgift 3 
v=np.array([0.21,0.25,0.28,0.33,0.44]) #initierar array för v
s=np.array([1.5,2.0,3.0,4.0,8.0]) #initierar array för s
a=0.17 #sätter a0 som variabel a
b=0.265 #sätter a1 som variabel b
x=np.linspace(0,10) #sätter grid för x
y=lambda x,a,b: (a*x)/(1+b*x) #skapar lambda funktion för beräknning av y

fig, ax = plt.subplots()
plt.scatter(s,v) #skapar en skatter för datan
ax.set_xlabel('S (mol)', fontsize=14) #sätter labels på axlar
ax.set_ylabel('v (mg/min)', fontsize=14)
ax.plot(x,y(x,a,b),color='C1') #plottar linjen
plt.show()

#%% uppgift 4
import scipy.optimize as opt #importerar modul optimize

def f(a,t): #funktion som returnerar beräkning av befolkningsutveckling
    return a[0]*np.exp(a[1]*t)

def res(a,year,population): #funktion som beräknar residualen mellan beräknade värden och befolkningsvärden
    return population-f(a,year)

def findX(y,a): #funktion returnerar x-värde vid ett visst y-värde
    return np.log(y/a[0])/a[1]

population=np.loadtxt('population.txt') #laddar in population.txt
years=np.arange(73) #skapar array över år
x=np.linspace(0,150) #skapar grid för x
a0=[population[0],0] #sätter ett startvärde som är första värdet i population och 0 som år
a,q=opt.leastsq(res,a0,args=(years, population)) #beräknar minstakvadrantanpassningen
y=f(a,x) #använder a från anpassningen som parameter för beräkning av y

x_at_15=findX(15,a) #användar funktion för att hitta x-värdet vid ett bestämt y-värde

fig, ax = plt.subplots()
plt.plot(years,population,'+',ms=5) #plottar ursprunglig data

ax.plot(x,y) #plottar beräknad data

plt.plot(x_at_15,15,'ro') #plottar punkt på beräknad linje där befolkningen är 15 miljarder
ax.text(x_at_15,15,f't={round(x_at_15,1)}') #placerar en text intill punkten som anger tiden t
ax.set_xlabel('t i år från 1951', fontsize=14) #sätter labels på axlar
ax.set_ylabel('befolkning i miljarder', fontsize=14)

y_at_2100=f(a,149) #beräknar befolkningsantal år 2100 4d
print('befolkning år 2100: ',f'{round(y_at_2100,1)} miljarder') #skriver ut resultatet
plt.show()

