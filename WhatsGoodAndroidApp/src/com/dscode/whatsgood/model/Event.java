package com.dscode.whatsgood.model;

import java.util.Date;

public class Event {	
	
	private int eventId;
	private String name;
	private String location;
	private Date startDate;
	private String genreDescription;
	private String promoterName;
	private String artistName;
	private Double price;
	private String eventAddress;

	public int getEventId() {
		return eventId;
	}
	public void setEventId(int eventId) {
		this.eventId = eventId;
	}
	public String getName() {
		return name;
	}
	public void setName(String name) {
		this.name = name;
	}
	public String getLocation() {
		return location;
	}
	public void setLocation(String location) {
		this.location = location;
	}
	public Date getStartDate() {
		return startDate;
	}
	public void setStartDate(Date startDate) {
		this.startDate = startDate;
	}
	public String getGenreDescription() {
		return genreDescription;
	}
	public void setGenreDescription(String genreDescription) {
		this.genreDescription = genreDescription;
	}
	public String getPromoterName() {
		return promoterName;
	}
	public void setPromoterName(String promoterName) {
		this.promoterName = promoterName;
	}
	public String getArtistName() {
		return artistName;
	}
	public void setArtistName(String artistName) {
		this.artistName = artistName;
	}
	
	public String getPriceRange() {
		if (price == null)
			return "Gratuíto";
		return "R$ " + price;
	}
	
	
	@Override
	public String toString() {
		return "Event [eventId=" + eventId + ", name=" + name + ", location="
				+ location + ", startDate=" + startDate + ", genreDescription="
				+ genreDescription + ", promoterName=" + promoterName
				+ ", artistName=" + artistName + "]";
	}

	public void setPrice(Double fullPrice) {
		price = fullPrice;
	}
	
	public void setEventAddress(String eventAddress) {
		this.eventAddress = eventAddress;
	}

	public String getEventAddress() {
		return eventAddress;
	}

}
