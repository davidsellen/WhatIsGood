package com.dscode.whatsgood.repository;

import java.util.ArrayList;
import java.util.Date;
import java.util.List;


import com.dscode.whatsgood.model.Event;
import com.dscode.whatsgood.model.IEventRepository;

public class EventRepository implements IEventRepository {

	private static List<Event> eventList;
	
	
	public EventRepository()
	{
		eventList = new ArrayList<Event>();
		
		Event titans = new Event();
		titans.setEventId(1);
		titans.setArtistName("Titans");
		titans.setGenreDescription("rock");
		titans.setPromoterName("Drink Nigth");
		titans.setName("Titans canta anos 80");
		titans.setLocation("Drink nigth, av sermambetiba, 2000, rj");
		titans.setStartDate(new Date());
		eventList.add(titans);
		
		Event cpm22 = new Event();
		cpm22.setEventId(2);
		cpm22.setArtistName("CPM 22");
		cpm22.setGenreDescription("rock");
		cpm22.setPromoterName("Rocking blues");
		cpm22.setName("CPM 22 Alive");
		cpm22.setLocation("Rocking blues, av das americas, 2500, rj");
		cpm22.setStartDate(new Date());
		eventList.add(cpm22);
		
		Event natiruts = new Event();
		natiruts.setEventId(3);
		natiruts.setArtistName("Natiruts");
		natiruts.setGenreDescription("reaggae");
		natiruts.setPromoterName("lunatic's");
		natiruts.setName("Natiruts reaggae power");
		natiruts.setLocation("lunatic's, av abelardo bueno, 1500, rj");
		natiruts.setStartDate(new Date());
		eventList.add(natiruts);
		
		Event robRock = new Event();
		robRock.setEventId(4);
		robRock.setArtistName("Rob rock");
		robRock.setGenreDescription("metal");
		robRock.setPromoterName("Barra Metal club");
		robRock.setName("Rob rock alive");
		robRock.setLocation("Barra Metal club, av abelardo bueno, 1800, rj");
		robRock.setStartDate(new Date());
		eventList.add(robRock);
		
		Event bride = new Event();
		bride.setEventId(5);
		bride.setArtistName("Bride");
		bride.setGenreDescription("metal");
		bride.setPromoterName("Alive rock beer");
		bride.setName("Bride show");
		bride.setLocation("Alive rock beer, rua pedro correia, 100, rj");
		bride.setStartDate(new Date());
		eventList.add(bride);
	}
	
	@Override
	public List<Event> GetByDate(Date startDate) {
		List<Event> matchEvents = new ArrayList<Event>();		
		for(Event e : eventList) {
			if (e.getStartDate().equals(startDate)){
				matchEvents.add(e);
			}		
		}		
		return matchEvents;
	}

	@Override
	public List<Event> GetByGenre(String genreDescription) {
		List<Event> matchEvents = new ArrayList<Event>();		
		for(Event e : eventList) {
			if (e.getGenreDescription() == genreDescription){
				matchEvents.add(e);
			}		
		}		
		return matchEvents;
	}

	@Override
	public List<Event> GetByArtist(String artistName) {
		List<Event> matchEvents = new ArrayList<Event>();		
		for(Event e : eventList) {
			if (e.getArtistName() == artistName){
				matchEvents.add(e);
			}		
		}		
		return matchEvents;
	}

}
